using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Enums;
using BattleShips.Core.Abstractions.Exceptions;
using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Abstractions.Repositories;
using BattleShips.Core.Abstractions.Services;

namespace BattleShips.Core.Services
{
    public class BattleService : IBattleService
    {
        private readonly IMapRepository mapRepository;
        private readonly IScoreRepository scoreRepository;

        public BattleService(IMapRepository mapRepository, IScoreRepository scoreRepository)
        {
            this.mapRepository = mapRepository;
            this.scoreRepository = scoreRepository;
        }
        public ShootResult Shoot(int row, int column)
        {
            var map = mapRepository.Map;
            if (map == null)
            {
                throw new MapNotInitializedException();
            }
            ValidateInput(row, column, map);
            var currentScore = GetScore();
            var field = map.Fields[row][column];

            if (field.IsShoot)
            {
                return new ShootResult() {LastShootStatus = ShootStatus.AlreadyShoot, Score = currentScore};
            }
            var result = new ShootResult()
            {
                Score = currentScore
            };
            field.IsShoot = true;
            if (field.Ship != null)
            {
                field.Ship.Coordinates
                   .FirstOrDefault(coordinate => coordinate.Row == row && coordinate.Column == column)
                   .IsHit = true;
                currentScore.Hits++;
                if (field.Ship.IsDestroyed)
                {
                    result.LastShootStatus = ShootStatus.Destroyed;
                    currentScore.Sinks++;
                }
                else
                {
                    result.LastShootStatus = ShootStatus.Hit;
                }
            }
            else
            {
                result.LastShootStatus = ShootStatus.Missed;
            }
            mapRepository.SaveMap(map);
            scoreRepository.SaveScore(currentScore);
            return result;

        }

        public Score GetScore()
        {
            var score = scoreRepository.Score;
            if (score == null)
            {
                score = new Score();
                scoreRepository.SaveScore(score);
            }

            return score;
        }

        private static void ValidateInput(int row, int column, Map map)
        {
            if (row >= map.Fields.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(row), $"Row cannot be greater than {map.Fields.Length - 1}");
            }

            if (column >= map.Fields[0].Length)
            {
                throw new ArgumentOutOfRangeException(nameof(row), $"Row cannot be greater than {map.Fields[0].Length - 1}");
            }
        }
    }
}
