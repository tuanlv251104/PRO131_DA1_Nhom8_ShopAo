using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
	public interface IMauSacServices
	{
		public List<MauSac> GetAllMau();
		public MauSac GetById(Guid id);
	}
}
