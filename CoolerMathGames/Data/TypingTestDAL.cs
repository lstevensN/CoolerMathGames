using CoolerMathGames.Interfaces;
using CoolerMathGames.Models;
using System;

namespace CoolerMathGames.Data
{
    public class TypingTestDAL : ITypingTestDAL
    {
        private ApplicationDbContext db;

        public TypingTestDAL(ApplicationDbContext indb)
        {
            db = indb;
        }
    }
}
