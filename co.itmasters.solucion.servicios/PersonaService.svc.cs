using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using co.itmasters.solucion.negocio;
using co.itmasters.solucion.vo;

namespace co.itmasters.solucion.servicios
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]


    public class PersonaService : IPersonaService, IDisposable
    {

        private PersonaNegocio _persona;
  
        private FuncionarioNegocio _funcionario;

        public void PersonaDatosBasicos_Update(PersonaVO pPersona)
        {
            try
            {

                _persona = new PersonaNegocio();
                _persona.PersonaDatosBasicos_Update(pPersona);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public void PersonaAcademia_Update(PersonaAcademiaVO pPersona)
        {
            try
            {

                _persona = new PersonaNegocio();
                _persona.PersonaAcademia_Update(pPersona);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public void PersonaExperiencia_Update(PersonaExperienciaVO pPersona)
        {
            try
            {

                _persona = new PersonaNegocio();
                _persona.PersonaExperiencia_Update(pPersona);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public void PersonaAptitud_Update(PersonaAptitudVO pPersona)
        {
            try
            {

                _persona = new PersonaNegocio();
                _persona.PersonaAptitud_Update(pPersona);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public void PersonaCondicionManoObra_Update(PersonaVO persona)
        {
            try
            {

                _persona = new PersonaNegocio();
                _persona.PersonaCondicionManoObra_Update(persona);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public List<AutocompleteActividadEconomica> ActEconomicaAutocomplete(AutocompleteActividadEconomica Act)
        {
            try
            {

                _persona = new PersonaNegocio();
                return _persona.ActEconomicaAutocomplete(Act);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public AutocompleteFormulario CiudadDepartamentoPaisForm(AutocompleteFormulario Autocomplete)
        {
            try
            {

                _persona = new PersonaNegocio();
                return _persona.CiudadDepartamentoPaisForm(Autocomplete);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public List<String> CiudadAutocompleteForm(AutocompleteFormulario Autocomplete)
        {
            try
            {

                _persona = new PersonaNegocio();
                return _persona.CiudadAutocompleteForm(Autocomplete);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public List<PersonaVO> Persona_DatosBasicos(PersonaVO pPersona)
        {
            try
            {

                _persona = new PersonaNegocio();
                return _persona.Persona_DatosBasicos(pPersona);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public List<PersonaVO> Persona_DatosBasicosPersonas(PersonaVO pPersona)
        {
            try
            {

                _persona = new PersonaNegocio();
                return _persona.Persona_DatosBasicosPersonas(pPersona);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
   
        public void Guardar_PersonaTercero(PersonaVO pPersona)
        {
            try
            {

                _persona = new PersonaNegocio();
                _persona.Guardar_PersonaTercero(pPersona);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public void Guardar_CambiarClave(FuncionarioVO pPersona)
        {
            try
            {

                _persona = new PersonaNegocio();
                _persona.Guardar_CambiarClave(pPersona);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public PersonaVO Buscar_Persona(PersonaVO pPersona)
        {
            try
            {

                _persona = new PersonaNegocio();
                return _persona.Buscar_Persona(pPersona);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public PersonaVO Buscar_personaId(PersonaVO pPersona)
        {
            try
            {

                _persona = new PersonaNegocio();
                return _persona.Buscar_personaId(pPersona);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public List<PersonaVO> Buscar_personaDatosModificados(PersonaVO pPersona)
        {
            try
            {

                _persona = new PersonaNegocio();
                return _persona.Buscar_personaDatosModificados(pPersona);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public void Guardar_Funcionario(FuncionarioVO funcionario)
        {
            try
            {

                _funcionario = new FuncionarioNegocio();
                _funcionario.Guardar_Funcionario(funcionario);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public FuncionarioVO Buscar_Funcionario(FuncionarioVO funcionario)
        {
            try
            {

                _funcionario = new FuncionarioNegocio();
                return _funcionario.Buscar_Funcionario(funcionario);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
       
        public virtual void Dispose()
        {

        }

    }
}
