using DinkToPdf;
using DinkToPdf.Contracts;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.ReportGenerator.Command
{
    public class ReportGeneratorCommandHandler : IRequestHandler<ReportGeneratorCommand, byte[]>
    {
        private IConverter _converter;

        public ReportGeneratorCommandHandler(IConverter converter)
        {
            _converter = converter;
        }

        public async Task<byte[]> Handle(ReportGeneratorCommand request, CancellationToken cancellationToken)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Grayscale,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10, Left = 10, Right = 10, Bottom= 10, Unit =DinkToPdf.Unit.Millimeters },
                DocumentTitle = request.FileTitle
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(request.HealthInsuranceName, request.ReportData),
                WebSettings = { DefaultEncoding = "utf-8",
                UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "styles.css") },
                FooterSettings = { FontName = "Arial", FontSize = 9, Right = "Página [page] de [toPage]" },
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return _converter.Convert(pdf);

        }
    }
}
