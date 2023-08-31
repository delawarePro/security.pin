using System;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace delaware.training.pin.Data
{
	public class GuessService
	{
		private int _pincode;

        public ConcurrentDictionary<int, int> Guesses { get; private set; } = new();

        public bool IsGuessed { get; private set; }

        public string GuessedPIN => IsGuessed ? _pincode.ToString("0000") : string.Empty;

        public GuessService()
		{
			SetRandomPin();
		}

		public void SetRandomPin()
		{
			var random = new Random();
			_pincode = random.Next(0, 9999);
			IsGuessed = false;
			Guesses = new();
        }

        public bool GuessPin(int guess)
        {
            Guesses.AddOrUpdate(guess, 1, (key, oldValue) => oldValue + 1);

			if (guess == _pincode)
			{
				IsGuessed = true;
				return true;
			}

			return false;
        }
    }
}

