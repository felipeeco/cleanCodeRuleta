using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cleanCodeRuleta.Classes;
using cleanCodeRuleta.Models;
using System.Transactions;

namespace cleanCodeRuleta.Controllers
{
	[ApiController]
	public class UserController : Controller
	{
		private int GenerateRandomNumber()
		{
			Random Rn = new Random();
			int RandomNumerResult = Rn.Next(36);

			return RandomNumerResult;
		}
		private int BetNumber(UserClass userClass)
		{
			int Total = 0;
			if (userClass.number == userClass.randomNumber)
			{
				Total = userClass.money * 5;
			}

			return Total;
		}
		private int BetColor(UserClass userClass)
		{
			int Total = 0;
			string UserNumberStatus = "Empty";
			string RandomNumberStatus = "Empty";
			if (userClass.number % 2 == 0){
				UserNumberStatus = "Even";
			}
			else{
				UserNumberStatus = "Odd";
			}
			if (userClass.randomNumber % 2 == 0){
				RandomNumberStatus = "Even";
			}
			else{
				RandomNumberStatus = "Odd";
			}
			if (UserNumberStatus == RandomNumberStatus){
				Total = (int)(float)(userClass.money * 1.8);
			}

			return Total;
		}
		[HttpPost]
		[Route("usuario/save-data")]
		public UserClass SaveData([FromBody] UserClass userClass)
		{
			try
			{
				using (cleanCodeRuletaDBContext db = new cleanCodeRuletaDBContext())
				{
					using (var transaccion = new TransactionScope())
					{
						User UserModel = new User();
						UserModel.DateCreated = DateTime.Now;
						UserModel.Number = userClass.number;
						UserModel.Money = userClass.money;
						UserModel.RadomNumber = GenerateRandomNumber();
						userClass.randomNumber = (int)UserModel.RadomNumber;
						if (userClass.color){
							UserModel.Result = BetColor(userClass);
							UserModel.Color = "True";
						}
						else {
							UserModel.Result = BetNumber(userClass);
							UserModel.Color = "False";
						}
						db.Add(UserModel);
						db.SaveChanges();
						userClass.result = (int)UserModel.Result;
						userClass.id = UserModel.Id;
						transaccion.Complete();
					}
				}
			}
			catch (Exception ex)
			{
				string error = ex.ToString();
			}

			return userClass;
		}
	}
}
