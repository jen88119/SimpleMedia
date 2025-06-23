﻿using System.Security.Cryptography;
using System.Text;

public static class PasswordHelper
{
	public static string GenerateSalt()
	{
		byte[] saltBytes = new byte[16];
		using (var rng = RandomNumberGenerator.Create())
		{
			rng.GetBytes(saltBytes);
		}
		return Convert.ToBase64String(saltBytes);
	}

	public static string HashPassword(string password, string salt)
	{
		var combined = Encoding.UTF8.GetBytes(password + salt);
		using (var sha256 = SHA256.Create())
		{
			return Convert.ToBase64String(sha256.ComputeHash(combined));
		}
	}
}
