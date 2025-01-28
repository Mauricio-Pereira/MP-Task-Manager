using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace MPTaskManager.Shared.Utils;

public class LowerCaseControllerRouteConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        // Força o nome do controlador para letras minúsculas
        var controllerName = controller.ControllerName.ToLowerInvariant();
        foreach (var selector in controller.Selectors)
        {
            if (selector.AttributeRouteModel != null)
            {
                selector.AttributeRouteModel.Template = selector.AttributeRouteModel.Template.Replace("[controller]", controllerName);
            }
        }
    }
}