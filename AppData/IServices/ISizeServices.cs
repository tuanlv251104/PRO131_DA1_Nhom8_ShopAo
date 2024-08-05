﻿using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
	public interface ISizeServices
	{
		public List<SizeSP> GetAllSize();
		public SizeSP GetById(Guid id);
	}
}
