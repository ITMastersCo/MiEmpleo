using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using co.itmasters.solucion.vo;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;


namespace co.itmasters.solucion.web.EncuestaNew
{
    public class DinamicForm
    {
        public List<EncuestaNewVO> Quiz;
        public HtmlGenericControl baseControl;
        public EventHandler ChkEvent;
        public EventHandler RblEvent;
        public DinamicForm(List<EncuestaNewVO> QuizData, HtmlGenericControl BaseControl, EventHandler CheckBoxListJustEvent, EventHandler RadioButtonListJustEvent)
        {
            Quiz = QuizData;
            baseControl = BaseControl;
            ChkEvent = CheckBoxListJustEvent;
            RblEvent = RadioButtonListJustEvent;
        }

        public DinamicForm(List<EncuestaNewVO> QuizData, HtmlGenericControl BaseControl)
        {
            Quiz = QuizData;
            baseControl = BaseControl;
        }

        public DinamicForm(HtmlGenericControl BaseControl)
        {
            baseControl = BaseControl;
        }

        public void pintar(Label QuizName, Label QuizDescription)
        {

            QuizName.Text = Quiz[0].encuesta.NomEncuesta;
            QuizDescription.Text = Quiz[0].encuesta.Descripcion;
            int tipopregunta = 0, idGrupo = 0, idPregunta = 0;
            foreach (EncuestaNewVO Con in Quiz)
            {
                if (idGrupo != Con.grupo.IdGrupo)
                {
                    Label Grupo = new Label();
                    Grupo.Text = Con.grupo.Descripcion;

                    Grupo.ID = "lblG_" + Con.grupo.IdGrupo.ToString();
                    baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("<tr><th style='background-color:#266884;'>"));
                    baseControl.Controls.AddAt(baseControl.Controls.Count, Grupo);
                    baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("</th></tr>"));

                    idGrupo = Con.grupo.IdGrupo;

                }

                if (idPregunta != Con.pregunta.IdPregunta)
                {
                    Label Pregunta = new Label();
                    Pregunta.Text = Con.pregunta.Descripcion;
                    Pregunta.ID = "lblP_" + Con.pregunta.IdPregunta.ToString();
                    baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("<tr class='modo2'><td  style='background-color:#7dc7db; color:#000000; font-weight:bold;'>"));
                    baseControl.Controls.AddAt(baseControl.Controls.Count, Pregunta);
                    baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("</td></tr>"));
                    idPregunta = Con.pregunta.IdPregunta;

                    tipopregunta = Con.pregunta.IdTipoPregunta;
                    List<EncuestaNewVO> preguntas = new List<EncuestaNewVO>();
                    String id = Con.encuesta.IdEncuesta + "-" + Con.pregunta.IdPregunta;


                    if (tipopregunta == 1) setRadioButtonList(RepeatDirection.Horizontal, id + "-" + 0, idPregunta, tipopregunta, 0);
                    else if (tipopregunta == 2) setRadioButtonList(RepeatDirection.Vertical, id + "-" + 0, idPregunta, tipopregunta, 0);
                    else if (tipopregunta == 3) setRadioButtonList(RepeatDirection.Horizontal, id + "-" + 1, idPregunta, tipopregunta, 1);
                    else if (tipopregunta == 4) setRadioButtonList(RepeatDirection.Vertical, id + "-" + 1, idPregunta, tipopregunta, 1);
                    else if (tipopregunta == 5) setCheckBoxList(RepeatDirection.Horizontal, id + "-" + 0, idPregunta, tipopregunta, 0);
                    else if (tipopregunta == 6) setCheckBoxList(RepeatDirection.Vertical, id + "-" + 0, idPregunta, tipopregunta, 0);
                    else if (tipopregunta == 7) setCheckBoxList(RepeatDirection.Horizontal, id + "-" + 1, idPregunta, tipopregunta, 1);
                    else if (tipopregunta == 8) setCheckBoxList(RepeatDirection.Vertical, id + "-" + 1, idPregunta, tipopregunta, 1);
                    else if (tipopregunta == 9) setTextbox(id + "-" + Con.preguntaRespuesta.IdPreguntaRespuesta + "-" + 0, "100", "", "", true);
                    else if (tipopregunta == 10) setTextbox(id + "-" + Con.preguntaRespuesta.IdPreguntaRespuesta + "-" + 0, "100", "Fecha", "", true);
                    else if (tipopregunta == 11) setTextbox(id + "-" + Con.preguntaRespuesta.IdPreguntaRespuesta + "-" + 0, "100", "Hora", "", true);
                    else if (tipopregunta == 12) setRadioButtonListImg(RepeatDirection.Horizontal, id + "-" + 0, idPregunta, tipopregunta, 0);
                }
            }
        }

        public void setRadioButtonListImg(RepeatDirection Dir, String Id, int idPregunta, int IdTipoPregunta, int jus)
        {
            RadioButtonList RblH = new RadioButtonList();
            RblH.RepeatDirection = Dir;
            RblH.Style.Add("width", "50%");
            RblH.Style.Add("text-align", "center");

            RblH.ID = Id.Split(new char[] { '-' })[0] + "-" + Id.Split(new char[] { '-' })[1] + "-0";
            List<EncuestaNewVO> preguntas = Quiz.Where(x => x.pregunta.IdPregunta == idPregunta && x.pregunta.IdTipoPregunta == IdTipoPregunta).ToList<EncuestaNewVO>();
            bool jusRes = false;
            string srcCara = "";

            foreach (EncuestaNewVO pregunta in preguntas)
            {
                jusRes = jusRes == false ? pregunta.preguntaRespuesta.Justificado : jusRes;


                string Cara = pregunta.preguntaRespuesta.Descripcion.Substring(0, 5);

                if (Cara == "CaraF")
                {
                    srcCara = "../Images/imgDiseño/happy.png";
                    RblH.Items.Add(new ListItem(pregunta.preguntaRespuesta.Descripcion.Remove(0, 5) + "<br/> <img src='" + srcCara + "'>", pregunta.preguntaRespuesta.IdPreguntaRespuesta.ToString() + "-" + pregunta.preguntaRespuesta.Justificado.ToString()));
                }
                if (Cara == "CaraM")
                {
                    srcCara = "../Images/imgDiseño/confused.png";
                    RblH.Items.Add(new ListItem(pregunta.preguntaRespuesta.Descripcion.Remove(0, 5) + "<br/> <img src='" + srcCara + "'>", pregunta.preguntaRespuesta.IdPreguntaRespuesta.ToString() + "-" + pregunta.preguntaRespuesta.Justificado.ToString()));


                }
                if (Cara == "CaraT")
                {
                    srcCara = "../Images/imgDiseño/sad.png";
                    RblH.Items.Add(new ListItem(pregunta.preguntaRespuesta.Descripcion.Remove(0, 5) + "<br/> <img src='" + srcCara + "'>", pregunta.preguntaRespuesta.IdPreguntaRespuesta.ToString() + "-" + pregunta.preguntaRespuesta.Justificado.ToString()));

                }
                if (Cara == "CaraC")
                {
                    srcCara = "../Images/imgDiseño/confundida.png";
                    RblH.Items.Add(new ListItem(pregunta.preguntaRespuesta.Descripcion.Remove(0, 5) + "<br/> <img src='" + srcCara + "'>", pregunta.preguntaRespuesta.IdPreguntaRespuesta.ToString() + "-" + pregunta.preguntaRespuesta.Justificado.ToString()));

                }
                if (Cara == "CaraE")
                {
                    srcCara = "../Images/imgDiseño/angry.png";
                    RblH.Items.Add(new ListItem(pregunta.preguntaRespuesta.Descripcion.Remove(0, 5) + "<br/> <img src='" + srcCara + "'>", pregunta.preguntaRespuesta.IdPreguntaRespuesta.ToString() + "-" + pregunta.preguntaRespuesta.Justificado.ToString()));

                }

            }
            if (jusRes)
            {
                RblH.SelectedIndexChanged += RblEvent;
                RblH.AutoPostBack = true;
                RblH.ID = Id;
            }
            baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("<tr class='modo2'><td align='left'>"));
            //validation(Id, "completar");
            baseControl.Controls.AddAt(baseControl.Controls.Count, RblH);
            baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("</td></tr>"));
            if (jus == 1 && jusRes)
            {
                setTextbox(idPregunta.ToString() + "-0-0-Jus", "89", "", "Justificación:", false);
            }
        }

        public void setCheckBoxList(RepeatDirection Dir, String Id, int idPregunta, int IdTipoPregunta, int jus)
        {
            CheckBoxList RblH = new CheckBoxList();
            RblH.RepeatDirection = Dir;
            RblH.Style.Add("width", "50%");
            RblH.Style.Add("text-align", "center");
            RblH.Attributes.Add("class", "chk");
            RblH.ID = Id.Split(new char[] { '-' })[0] + "-" + Id.Split(new char[] { '-' })[1] + "-0";
            List<EncuestaNewVO> preguntas = Quiz.Where(x => x.pregunta.IdPregunta == idPregunta && x.pregunta.IdTipoPregunta == IdTipoPregunta).ToList<EncuestaNewVO>();
            bool jusRes = false;
            foreach (EncuestaNewVO pregunta in preguntas)
            {
                jusRes = jusRes == false ? pregunta.preguntaRespuesta.Justificado : jusRes;
                RblH.Items.Add(new ListItem(pregunta.preguntaRespuesta.Descripcion, pregunta.preguntaRespuesta.IdPreguntaRespuesta.ToString() + "-" + pregunta.preguntaRespuesta.Justificado.ToString()));
            }
            if (jusRes)
            {
                RblH.SelectedIndexChanged += ChkEvent;
                RblH.AutoPostBack = true;
                RblH.ID = Id;
            }
            baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("<tr><td align='center'>"));
            //validationChk("Completar");
            baseControl.Controls.AddAt(baseControl.Controls.Count, RblH);
            baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("</td></tr>"));
            if (jus == 1 && jusRes)
            {
                setTextbox(idPregunta.ToString() + "-0-0-Chk", "89", "", "Justificación:", false);
            }
        }

        public void setRadioButtonList(RepeatDirection Dir, String Id, int idPregunta, int IdTipoPregunta, int jus)
        {
            RadioButtonList RblH = new RadioButtonList();
            RblH.RepeatDirection = Dir;
            RblH.Style.Add("width", "100%");
            RblH.Style.Add("text-align", "center");
            RblH.ID = Id.Split(new char[] { '-' })[0] + "-" + Id.Split(new char[] { '-' })[1] + "-0";
            List<EncuestaNewVO> preguntas = Quiz.Where(x => x.pregunta.IdPregunta == idPregunta && x.pregunta.IdTipoPregunta == IdTipoPregunta).ToList<EncuestaNewVO>();
            bool jusRes = false;
            foreach (EncuestaNewVO pregunta in preguntas)
            {
                jusRes = jusRes == false ? pregunta.preguntaRespuesta.Justificado : jusRes;
                RblH.Items.Add(new ListItem(pregunta.preguntaRespuesta.Descripcion, pregunta.preguntaRespuesta.IdPreguntaRespuesta.ToString() + "-" + pregunta.preguntaRespuesta.Justificado.ToString()));
            }
            if (jusRes)
            {
                RblH.SelectedIndexChanged += RblEvent;
                RblH.AutoPostBack = true;
                RblH.ID = Id;
            }
            //baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("<tr class='modo2'><td align='center'>"));
            baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("<tr class='modo2'><td align='center'>"));
            //validation(Id, "completar");
            baseControl.Controls.AddAt(baseControl.Controls.Count, RblH);
            baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("</td></tr>"));
            if (jus == 1 && jusRes)
            {
                setTextbox(idPregunta.ToString() + "-0-0-Jus", "89", "", "Justificación:", false);
            }
        }

        public void setTextbox(String Id, String Width, String Class, String message, bool Enabled)
        {
            TextBox txt = new TextBox();
            txt.ID = Id;
            txt.Style.Add("width", Width + "%");
            txt.Attributes.Add("class", Class);
            txt.CssClass = "form-control";
            txt.Enabled = Enabled;
            txt.MaxLength = 450;
            txt.Attributes.Add("placeholder", "Máximo 450 caracteres");
            txt.Attributes.Add("aria-describedby", "basic-addon1");
            baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("<tr class='modo2'><td align='center' style='border-bottom:solid 1px;'> " + message));
            //validation(Id,"completar");
            baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("<div class='input-group'>  <span class='input-group-addon'  id='basic-addon1'><span class='fa fa-question-circle-o fa-lg text-primary'></span> </span>"));
            baseControl.Controls.AddAt(baseControl.Controls.Count, txt);
            baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("</div>"));
            baseControl.Controls.AddAt(baseControl.Controls.Count, new LiteralControl("<br></td></tr>"));
        }

        public void answer(List<EncuestaNewVO> answers)
        {
            foreach (Control control in baseControl.Controls)
            {
                if (control is RadioButtonList || control is TextBox || control is CheckBoxList)
                {
                    int IdPregunta = Convert.ToInt32(control.ID.Split(new char[] { '-' })[1]);

                    foreach (EncuestaNewVO answer in answers)
                    {
                        if (IdPregunta == answer.pregunta.IdPregunta)
                        {
                            if (control is RadioButtonList)
                            {
                                foreach (ListItem item in ((RadioButtonList)control).Items)
                                {
                                    List<String> values = item.Value.Split(new char[] { '-' }).ToList<String>();
                                    if (Convert.ToInt32(values[0]) == answer.preguntaRespuesta.IdPreguntaRespuesta)
                                    {
                                        item.Selected = true;
                                        if (Convert.ToBoolean(values[1]))
                                        {
                                            ((TextBox)(baseControl.FindControl(IdPregunta + "-0-0-Jus"))).Text = answer.resultado.Justificacion;
                                            ((TextBox)(baseControl.FindControl(IdPregunta + "-0-0-Jus"))).Enabled = true;
                                        }
                                    }
                                }
                            }
                            else if (control is CheckBoxList)
                            {
                                foreach (ListItem item in ((CheckBoxList)control).Items)
                                {
                                    List<String> values = item.Value.Split(new char[] { '-' }).ToList<String>();
                                    if (Convert.ToInt32(values[0]) == answer.preguntaRespuesta.IdPreguntaRespuesta)
                                    {
                                        item.Selected = true;
                                        if (Convert.ToBoolean(values[1]))
                                        {
                                            ((TextBox)(baseControl.FindControl(IdPregunta + "-0-0-Chk"))).Text = answer.resultado.Justificacion;
                                            ((TextBox)(baseControl.FindControl(IdPregunta + "-0-0-Chk"))).Enabled = true;
                                        }
                                    }
                                }
                            }
                            else if (control is TextBox)
                            {
                                ((TextBox)control).Text = answer.resultado.Justificacion;
                            }
                        }
                    }
                }
            }
        }

        public bool validate()
        {
            bool ok = true;
            foreach (Control control in baseControl.Controls)
            {
                if (control is RadioButtonList)
                {
                    if (string.IsNullOrEmpty((control as RadioButtonList).SelectedValue))
                    {
                        (control as RadioButtonList).Style.Add("background-color", "rgba(241, 0, 0, 0.14)");
                        ok = false;
                    }
                    else
                    {
                        (control as RadioButtonList).Style.Add("background-color", "white");
                    }
                }
                else if (control is CheckBoxList)
                {
                    if (!(control as CheckBoxList).Items.Cast<ListItem>().Any(x => x.Selected))
                    {
                        (control as CheckBoxList).Style.Add("background-color", "rgba(241, 0, 0, 0.14)");
                        ok = false;
                    }
                    else
                    {
                        (control as CheckBoxList).Style.Add("background-color", "white");
                    }
                }
                else if (control is TextBox)
                {
                    if (string.IsNullOrEmpty((control as TextBox).Text) && (control as TextBox).Enabled == true)
                    {
                        (control as TextBox).Style.Add("background-color", "rgba(241, 0, 0, 0.14)");
                        ok = false;
                    }
                    else
                    {
                        (control as TextBox).Style.Add("background-color", "white");
                    }
                }
            }
            return ok;
        }

    }
}