using MyMusic.Application.Models;
using MyMusic.Application.UseCases.Abstratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Application.UseCases
{
    public class CasesValidationUseCase : ICasesValidationUseCase
    {
        public bool ValidationSearchMusic(string name)
        {
            if (name.Length < 3 || String.IsNullOrEmpty(name))
            {
                return false;
            }

            return true;
        }
        public bool ValidationCheckListMusic(List<AcquiredMusics> musicList)
        {
            if (musicList.ToArray().Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}
