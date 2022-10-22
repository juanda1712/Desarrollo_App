using System.Security.Claims;

namespace API_BD.Controllers
{
    public static class Funciones_Varias
    {

        public static bool ValidarToken(ClaimsIdentity identity)
        {

			try
			{

				if (identity.Claims.Count() == 0)
				{
					return false;
				}
				return true;

			}
			catch (Exception ex)
			{

				return false;
			}


        }


    }
}
