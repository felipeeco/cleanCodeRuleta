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
		[HttpPost]
		[Route("usuario/ruleta")]
		public int SaveData([FromBody] UserClass userClass)
		{
			int answer = 0;
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
						Random Rn = new Random();
						int RandomNumerResult = Rn.Next(25);
						UserModel.RadomNumber = RandomNumerResult;
						db.Add(UserModel);
						db.SaveChanges();
						transaccion.Complete();
						answer = 1;
					}
				}
			}
			catch (Exception)
			{

				answer = 2;
			}
			return answer;
		}
	}
}
