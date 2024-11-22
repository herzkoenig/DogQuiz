using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogQuiz.Domain.Aggregates.General.Entities;
public class FileUploadRequest
{
	public string? FileName { get; set; }
	public long FileSize { get; set; }
	public string? ContentType { get; set; }
	public string? FileExtension { get; set; }
}
