﻿using Restore_Zadohin3IS_24.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Restore_Zadohin3IS_24
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Контекст данных
        public static RestoDb_ZadohinEntities context = new RestoDb_ZadohinEntities();
    }
}