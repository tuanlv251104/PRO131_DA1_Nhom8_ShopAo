﻿using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
	public  interface IDanhMucServices
	{
		public List<DanhSachSP> GetAllDanhMuc();
		public DanhSachSP GetById(Guid id);
	}
}
