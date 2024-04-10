using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using co.itmasters.solucion.dao;
using co.itmasters.solucion.vo;

namespace co.itmasters.solucion.negocio
{
    public class PersonaNegocio
    {
        PersonaDao _persona;
        public PersonaNegocio()
        {

            _persona = new PersonaDao();
        }


        public void PersonaDatosBasicos_Update(PersonaVO pPersona)
        {
            _persona.PersonaDatosBasicos_Update(pPersona);
        } 
        public void PersonaAcademia_Update(PersonaAcademiaVO pPersona)
        {
            _persona.PersonaAcademia_Update(pPersona);
        } 
        public void PersonaExperiencia_Update(PersonaExperienciaVO pPersona)
        {
            _persona.PersonaExperiencia_Update(pPersona);
        }
        public void PersonaAptitud_Update(PersonaAptitudVO pPersona)
        {
            _persona.PersonaAptitud_Update(pPersona);
        }
        public void PersonaCondicionManoObra_Update(PersonaVO persona)
        {
            _persona.PersonaCondicionManoObra_Update(persona);
        }
        public List<AutocompleteActividadEconomica> ActEconomicaAutocomplete(AutocompleteActividadEconomica Act)
        {
            return _persona.ActEconomicaAutocomplete(Act);
        }

      
        public AutocompleteFormulario CiudadDepartamentoPaisForm(AutocompleteFormulario Autocomplete)
        {
            return _persona.CiudadDepartamentoPaisForm(Autocomplete);
        }


        public List<String> CiudadAutocompleteForm(AutocompleteFormulario Autocomplete)
        {
            return _persona.CiudadAutocompleteForm(Autocomplete);
        }
        
    

        public void Guardar_PersonaTercero(PersonaVO pPersona)
        {
            _persona.Guardar_PersonaTercero(pPersona);
        }

       

        public void Guardar_CambiarClave(FuncionarioVO pPersona)
        {
            _persona.Guardar_CambiarClave(pPersona);
        }

     
        public PersonaVO Buscar_Persona(PersonaVO persona)
        {
            return _persona.Buscar_persona(persona);
        }

        public PersonaVO Buscar_personaId(PersonaVO ppersona)
        {
            return _persona.Buscar_personaId(ppersona);
        }

        public List<PersonaVO> Buscar_personaDatosModificados(PersonaVO ppersona)
        {
            return _persona.Buscar_personaDatosModificados(ppersona);
        }

        public List<PersonaVO> Persona_DatosBasicos(PersonaVO pPersona)
        {
            return _persona.Persona_DatosBasicos(pPersona);
        }

        public List<PersonaVO> Persona_DatosBasicosPersonas(PersonaVO pPersona)
        {
            return _persona.Persona_DatosBasicosPersonas(pPersona);
        }


        public PersonaVO Buscar_personaFormulario(PersonaVO pAlumno)
        {
            return _persona.Buscar_personaFormulario(pAlumno);
        }


    }
}
