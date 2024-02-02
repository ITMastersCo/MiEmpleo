using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using co.itmasters.solucion.vo;
using MercadoPago.Resource.User;
using co.itmasters.solucion.dao.code;
using System.Numerics;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MercadoPago" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MercadoPago.svc o MercadoPago.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MercadoPagoService : IMercadoPagoService
    {    
        EmpresaService _Empresa;
        public async Task<Preference> CrearPreferencia(EmpresaVO newPlanAdquirido)
        {

            MercadoPagoConfig.AccessToken = "APP_USR-2148574929506385-013011-2a326a05936b10aaeafa5b0b78b61be6-1660977390";

            //Crea el objeto de request de la preference
            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                      {
                        new PreferenceItemRequest
                        {
                            Title = newPlanAdquirido.Oferta.nomPlan,
                            Quantity = 1,
                            CurrencyId = "COP",
                            UnitPrice = Convert.ToInt32(newPlanAdquirido.Oferta.valorPlan),
                        }

                },
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "http://localhost:8080/Empresa/PagoAprobado.aspx",
                    Failure = "http://localhost:8080/Empresa/PagoAprobado.aspx",
                    Pending = "http://localhost:8080/Empresa/PagoAprobado.aspx",
                },
                AutoReturn = "approved",
            };

            // Crea la preferencia usando el client
            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(request);
            CreatePlanAdquirido(newPlanAdquirido, preference.Id);
            return preference;
        }
        private void CreatePlanAdquirido(EmpresaVO empresa, string preferenceId)
        {
            try
            {
                EmpresaVO newEmpresa = new EmpresaVO();
                OfertaVO newPlan = new OfertaVO();

                newEmpresa.typeModify = TipoConsulta.MODIFY_INSERT;
                newEmpresa.idUsuario = empresa.idUsuario;
                newEmpresa.idEmpresa = empresa.idEmpresa;
                newPlan.idPlan = Convert.ToInt32(empresa.Oferta.idPlan);
                newPlan.preference_id = preferenceId;
                newPlan.vigenciaPlan = empresa.Oferta.vigenciaPlan;
                newPlan.numeroOfertas = empresa.Oferta.numeroOfertas;
                newPlan.valorPlan = empresa.Oferta.valorPlan;
                newEmpresa.Oferta = newPlan;

                _Empresa = new EmpresaService();
                _Empresa.CreatePlanAdquirido(newEmpresa);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
