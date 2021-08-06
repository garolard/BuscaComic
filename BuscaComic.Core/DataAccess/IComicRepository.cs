﻿using BuscaComic.Core.Models;
using System.Threading.Tasks;

namespace BuscaComic.Core.DataAccess
{
    interface IComicRepository
    {
        Task<Comic[]> SearchComicsByName(string name);
    }
}