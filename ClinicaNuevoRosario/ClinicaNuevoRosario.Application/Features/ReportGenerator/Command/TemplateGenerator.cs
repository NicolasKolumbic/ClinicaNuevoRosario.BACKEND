using ClinicaNuevoRosario.Application.Models.ReportGenerator;
using System.Text;

namespace ClinicaNuevoRosario.Application.Features.ReportGenerator.Command
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString(List<HealthInsuranceReport> reportData)
        {

            var sb = new StringBuilder();
            sb.AppendFormat(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'>							
									<div class='left-content'>
										<div>
											<img src='{0}' class='brand' />
										</div>
										<p>Av. Belgrano 2300 - Tel 3414851241</p>
									</div>
									<div class='right-content'>
										<h2 class='mt-0'>Reporte Prestadoras</h2>
										<p class='mt-0'>Obra Social/Prepaga: OSDE</p>
										<p class='mt-0 mt-1'>fecha: {1}</p>
									</div>
								</div>
                                <table>
                                    <tr>
                                        <th>Fecha</th>
                                        <th>Nombre Completo</th>
                                        <th>Numero de afiliado</th>
                                        <th>Plan</th>
                                        <th>Profesional</th>
                                        <th>Especialidad</th>
                                        <th>Tipo de Servicio</th>
                                    </tr>", Path.Combine(Directory.GetCurrentDirectory(), "Assets", "logo.jpg"), DateTime.Now.ToShortDateString());

            foreach (var row in reportData)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                  </tr>", row.Date, row.PatientFullName, row.HealthInsuranceNumber, row.Plan, row.ProfesionalFullName, row.HealthInsuranceName, row.ServiceType);
            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }


}


