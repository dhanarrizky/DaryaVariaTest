namespace DaryaVariaTest.Helper;
public static class ObjConverter {
    public static ObjTarget ConvertTo<ObjTarget>(object source) where ObjTarget : new() {
        var target = new ObjTarget();
        var sourceProperties = source.GetType().GetProperties();
        var targetProperties = typeof(ObjTarget).GetProperties();

        foreach(var sprop in sourceProperties) {
            var tprop = targetProperties.FirstOrDefault(tp => tp.Name == sprop.Name && tp.PropertyType == sprop.PropertyType);
            if(tprop != null) {
                tprop.SetValue(target, sprop.GetValue(source));
            }
        }

        return target;
    }
}