using MyMusic.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Application.UseCases.Abstratcs
{
    public interface ISearchAllMusicsUseCase
    {
        List<AcquiredMusicsResponse> Execute();
    }
}
