using System;
using CloudinaryDotNet.Actions;

namespace Memories.Interfaces
{
	public interface IPhotoService
	{
		Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
		Task<DeletionResult> DeletePhotoAsync(string publicId);

		
	}
}

