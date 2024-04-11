using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using co.itmasters.solucion.vo;
using System.Data;

namespace co.itmasters.solucion.servicios
{
    [ServiceContract]
    public interface IPersonaService
    {
  

        [OperationContract]
        void PersonaDatosBasicos_Update(PersonaVO pPersona);

        [OperationContract]
        void PersonaAcademia_Update(PersonaAcademiaVO pPersona);

        [OperationContract]
        void PersonaExperiencia_Update(PersonaExperienciaVO pPersona);
        
        [OperationContract]
        void PersonaAptitud_Update(PersonaAptitudVO pPersona);

        [OperationContract]
        void PersonaCondicionManoObra_Update(PersonaVO persona);

        [OperationContract]
        List<AutocompleteActividadEconomica> ActEconomicaAutocomplete(AutocompleteActividadEconomica Act);

        [OperationContract]
        AutocompleteFormulario CiudadDepartamentoPaisForm(AutocompleteFormulario Autocomplete);

        [OperationContract]
        List<String> CiudadAutocompleteForm(AutocompleteFormulario Autocomplete);


        [OperationContract]
        List<PersonaVO> Persona_DatosBasicos(PersonaVO pPersona);


        [OperationContract]
        List<PersonaVO> Persona_DatosBasicosPersonas(PersonaVO pPersona);

        [OperationContract]
        void Guardar_PersonaTercero(PersonaVO pPersona);

        [OperationContract]
        void Guardar_CambiarClave(FuncionarioVO pPersona);



        [OperationContract]
        PersonaVO Buscar_Persona(PersonaVO pPersona);

        [OperationContract]
        PersonaVO Buscar_personaId(PersonaVO ppersona);

        [OperationContract]
        List<PersonaVO> Buscar_personaDatosModificados(PersonaVO ppersona);


        [OperationContract]
        void Guardar_Funcionario(FuncionarioVO funcionario);


        [OperationContract]
        FuncionarioVO Buscar_Funcionario(FuncionarioVO funcionario);

    }
}
