using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogQuiz.Application.Breeds.CreateBreedFact;
public interface IBreedFactGeneratorService
{
	Task<string?> GetRandomFactForBreedAsync(int breedId);
}