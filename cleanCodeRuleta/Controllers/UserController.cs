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
		public UserClass Ruleta([FromBody] UserClass userClass)
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

					}
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
