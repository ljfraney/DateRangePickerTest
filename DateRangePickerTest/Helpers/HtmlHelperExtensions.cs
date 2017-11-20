using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace DateRangePickerTest
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString DateRangeJavaScriptFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            var modelProperty = memberExpression.Member.Name;

            var js = string.Format(@"<script type=""text/javascript"">
                $(function() {{
                    $('#{0}').daterangepicker();

                    var {0}_SetHiddenFields = function() {{
                        var startDate = $('#{0}').data('daterangepicker').startDate.format('l');
                        $('#{0}_StartDateTime').val(startDate);

                        var endDate = $('#{0}').data('daterangepicker').endDate.format('l');
                        $('#{0}_EndDateTime').val(endDate);
                    }}

                    if ($('#{0}').val()) {{
                        {0}_SetHiddenFields();
                    }}

                    $('#{0}').change({0}_SetHiddenFields);
                }});
            </script>", modelProperty);

            return MvcHtmlString.Create(js);
        }
    }
}