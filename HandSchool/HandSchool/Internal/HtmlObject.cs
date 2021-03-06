﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Xamarin.Forms;

namespace HandSchool.Internal
{
    public interface IHtmlObject
    {
        string Id { get; }
        void ToHtml(StringBuilder sb, bool full = true);
    }

    namespace HtmlObject
    {
        public class Form : IHtmlObject
        {
            public List<IHtmlObject> Children { get; set; } = new List<IHtmlObject>();
            public string SubmitOption { get; set; } = "return false";
            public string Id { get; private set; }

            public void ToHtml(StringBuilder sb, bool full = true)
            {
                Id = Guid.NewGuid().ToString("N").Substring(0, 6);
                sb.Append($"<form class=\"setting-form-group\" onsubmit=\"{SubmitOption}\">");
                Children.ForEach((obj) => obj.ToHtml(sb));
                sb.Append("</form>");
                //throw new NotImplementedException();
            }
        }

        public class FormGroup : IHtmlObject
        {
            public List<IHtmlObject> Children { get; set; } = new List<IHtmlObject>();
            public string Id => "";

            public void ToHtml(StringBuilder sb, bool full = true)
            {
                sb.Append("<div class=\"form-group\">");
                Children.ForEach((obj) => obj.ToHtml(sb));
                sb.Append("</div>");
            }
        }

        public class Check : IHtmlObject
        {
            public string Name { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string Value { get; set; } = string.Empty;
            public string ValueDescription { get; set; } = string.Empty;
            public string Id { get; private set; }

            public void ToHtml(StringBuilder sb, bool full = true)
            {
                if (full) sb.Append($"<label><b>{Title}</b></label><br>");
                Id = Guid.NewGuid().ToString("N").Substring(0, 6);
                sb.Append("<div class=\"custom-control custom-control-inline custom-checkbox\">");
                sb.Append($"<input type=\"checkbox\" class=\"custom-control-input\" name=\"{Name}[]\" id=\"{Name}{Id}\" value=\"{Value}\">");
                sb.Append($"<label class=\"custom-control-label\" for=\"{Name}{Id}\">{ValueDescription}</label></div>");
                if (full && Description.Length > 0) sb.Append($"<small class=\"form-text text-muted\">{Description}</small>");
            }
        }

        public class Radio : IHtmlObject
        {
            public string Name { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public NameValueCollection Options { get; set; } = new NameValueCollection();
            public string Id => "";

            public void ToHtml(StringBuilder sb, bool full = true)
            {
                if (full) sb.Append($"<label><b>{Title}</b></label><br>");
                foreach (var key in Options.AllKeys)
                {
                    var guid = Guid.NewGuid().ToString("N").Substring(0, 6);
                    sb.Append("<div class=\"custom-control custom-control-inline custom-radio\">");
                    sb.Append($"<input type=\"radio\" class=\"custom-control-input\" name=\"{Name}\" id=\"{Name}{guid}\" value=\"{key}\">");
                    sb.Append($"<label class=\"custom-control-label\" for=\"{Name}{guid}\">{Options["key"]}</label></div>");
                }
                if (full && Description.Length > 0) sb.Append($"<small class=\"form-text text-muted\">{Description}</small>");
            }
        }

        public enum InputType
        {
            text,
            password,
            email
        }

        public class Input : IHtmlObject
        {
            public string Name { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public InputType Type { get; set; } = InputType.text;
            public string Placeholder { get; set; } = string.Empty;
            public string Default { get; set; } = string.Empty;
            public string Id { get; private set; }

            public void ToHtml(StringBuilder sb, bool full = true)
            {
                Id = string.Empty;
                if (full)
                {
                    Id = Guid.NewGuid().ToString("N").Substring(0, 6);
                    sb.Append($"<label for=\"{Id}\"><b>{Title}</b></label><input type=\"{Type.ToString()}\" name=\"{Name}\" placeholder=\"{Placeholder}\" value=\"{Default}\" id=\"{Id}\">");
                }
                else
                    sb.Append($"<input type=\"{Type.ToString()}\" name=\"{Name}\" placeholder=\"{Placeholder}\" value=\"{Default}\">");
                if (full && Description.Length > 0)
                    sb.Append($"<small id=\"{Id}\" class=\"form-text text-muted\">{Description}</small>");
            }
        }

        public class Select : IHtmlObject
        {
            public string Name { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public NameValueCollection Options { get; set; } = new NameValueCollection();
            public string Id { get; private set; }

            public void ToHtml(StringBuilder sb, bool full = true)
            {
                Id = string.Empty;
                if (full)
                {
                    Id = Guid.NewGuid().ToString("N").Substring(0, 6);
                    sb.Append($"<label for=\"{Id}\"><b>{Title}</b></label><select class=\"form-control\" name=\"{Name}\" id=\"{Id}\">");
                }
                else
                    sb.Append($"<select class=\"form-control\" name=\"{Name}\">");
                foreach (var key in Options?.AllKeys)
                    sb.Append($"<option value=\"{key}\">{Options[key]}</option>");
                sb.Append("</select>");
                if (full && Description.Length > 0)
                    sb.Append($"<small id=\"{Id}\" class=\"form-text text-muted\">{Description}</small>");
            }
        }

        public class Table : IHtmlObject
        {
            public string Class { get; set; } = "table table-sm";
            public List<string> Column { get; set; } = new List<string>();
            public string Id => "";
            public string BodyId { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 6);

            public void ToHtml(StringBuilder sb, bool full = true)
            {
                sb.Append($"<table class=\"{Class}\"><thead><tr>");
                Column.ForEach((s) => sb.Append($"<th scope=\"col\">{s}</th>"));
                sb.Append($"</tr></thead><tbody id=\"{BodyId}\"></tbody></table>");
            }
        }

        public class Button : IHtmlObject
        {
            public string Title { get; set; } = " 提交 ";
            public string Color { get; set; } = "primary";
            public string Type { get; set; } = "type=\"submit\"";
            public string Id => "";

            public void ToHtml(StringBuilder sb, bool full = true)
            {
                if (full) sb.Append("<div class=\"form-group\">");
                sb.Append($"<button {Type} class=\"btn btn-{Color}\">{Title}</button>");
                if (full) sb.Append("</div>");
            }
        }

        public class Div : IHtmlObject
        {
            public string Class { get; set; } = string.Empty;
            public string Id { get; set; } = string.Empty;
            public List<IHtmlObject> Children { get; set; } = new List<IHtmlObject>();

            public void ToHtml(StringBuilder sb, bool full = true)
            {
                sb.Append("<div");
                if (Id == string.Empty) sb.Append(" id=\"" + Id + "\"");
                if (Class == string.Empty) sb.Append(" class=\"" + Class + "\"");
                sb.Append(">");
                Children.ForEach((obj) => obj.ToHtml(sb));
                sb.Append("</div>");
            }
        }

        public class Row : IHtmlObject
        {
            public List<IHtmlObject>[] Children { get; set; }
            public int[] RowWidth { get; set; }
            public string Id => "";

            public void ToHtml(StringBuilder sb, bool full = true)
            {
                sb.Append("<div class=\"row\"" + (Id == "" ? "" : " id=\""+ Id +"\"") + ">");
                for (int i = 0; i < RowWidth.Length; i++)
                {
                    sb.Append($"<div class=\"col-12 col-md-{RowWidth[i]}\">");
                    Children[i].ForEach((obj) => obj.ToHtml(sb));
                    sb.Append("</div>");
                }
                sb.Append("</div>");
            }
        }

        public class UnorderedList : IHtmlObject
        {
            public string Id => "";
            public List<string> Children { get; set; } = new List<string>();
                
            public void ToHtml(StringBuilder sb, bool full = true)
            {
                sb.Append("<ul>");
                Children.ForEach((val) => sb.Append($"<li>{val}</li>"));
                sb.Append("</ul>");
            }
        }

        public class MasterDetail : IHtmlObject
        {
            public string Id { get; private set; } = Guid.NewGuid().ToString("N").Substring(0, 6);
            public Form InfoGather { get; set; }
            public List<IHtmlObject> Children { get; set; } = new List<IHtmlObject>();

            public void ToHtml(StringBuilder sb, bool full = true)
            {
                sb.Append("<div class=\"row\"><div class=\"col-12 col-md-3 order-md-1 pt-3\">");
                InfoGather.ToHtml(sb);
                sb.Append("</div><div class=\"col-12 col-md-9 mt-3 mb-3 pr-4 pl-4 order-md-0\" id=\"" + Id + "\">");
                Children.ForEach((obj) => obj.ToHtml(sb));
                sb.Append("</div></div>");
            }
        }

        public class RawHtml : IHtmlObject
        {
            public string Raw { get; set; } = string.Empty;
            public string Id => "";

            public void ToHtml(StringBuilder sb, bool full = true)
            {
                sb.Append(Raw);
            }

            public static explicit operator RawHtml(string value)
            {
                return new RawHtml { Raw = value };
            }
        }

        public class Bootstrap : IHtmlObject
        {
            public string Title { get; set; } = "WebViewPage";
            public const string Charset = "utf-8";
            public List<IHtmlObject> Children { get; set; } = new List<IHtmlObject>();
            public List<string> JavaScript { get; set; } = new List<string>();
            public string Css { get; set; } = "";
            public string Id => "";

            public void ToHtml(StringBuilder sb, bool full = true)
            {
                sb.Append($"<!doctype html><html><head><meta charset=\"{Charset}\"><base href=\"{{webview_base_url}}\"></base>");
                sb.Append("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">");
                sb.Append($"<link rel=\"stylesheet\" href=\"bootstrap.css\"><style>{Css}</style><title>{Title}</title></head><body><div class=\"container-fluid\">");
                Children.ForEach((obj) => obj.ToHtml(sb));
                sb.Append("</div><script src=\"jquery.js\"></script><script src=\"popper.js\"></script><script src=\"json.js\"></script><script src=\"bootstrap.bundle.js\"></script>");
                JavaScript.ForEach((obj) => sb.Append("<script>" + obj + "</script>"));
                sb.Append("</body></html>");
            }
        }
    }
}
