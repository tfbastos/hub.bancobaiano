using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Banco.Baiano.Interface
{
    public interface ILogin
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
