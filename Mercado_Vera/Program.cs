﻿using Mercado_Vera.View.GerFornecedor;
using Mercado_Vera.View.GerProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado_Vera
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FmrPesquisaFor());
            //FmrProduto
            //FmrCaixa
            //FmrPesquisa
            //tstExcluir
            //FmrPesquisaFor

        }
    }
}
