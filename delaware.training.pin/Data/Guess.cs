using System.ComponentModel.DataAnnotations;

namespace delaware.training.pin.Data
{
    public class Guess
	{
		[Required]
		[MaxLength(4)]
		[Range(0,9999)]
		public int? Value { get; set; }
	}
}

