using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogQuiz.Application.BreedManagement.Interfaces;
public interface IBreedFactGeneratorService
{
	Task<string?> GetRandomFactForBreedAsync(int breedId);
}