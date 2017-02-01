<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %><%@ Import Namespace="System.IO" %>
<%

    var dbs = new CarProject.DBSEF.CarAutomationEntities();
    var products = dbs.Products.OrderByDescending(p => p.ProductId).Take(50);
    var rand = new Random();
    
 %><?xml version="1.0" encoding="UTF-8"?><rss version="2.0"><channel>
    <title>فروشگاه قطعات یدکی | کلینیک خودرو</title>
    <link><%= Url.Action("ProductsList", "Store", new { area = "" }, Request.Url.Scheme)%></link>
    <description>فروشگاه اینترنتی خدمات و قطعات یدکی خودرو</description>

    <%foreach (var item in products) { 
        var pathproducts = "~/Publics/Gallery/ProductImages/" + item.ProductId;
        var dicinfo = new DirectoryInfo(Server.MapPath(pathproducts));
        var url = Url.RouteUrl("infoRoute", new { controller = "Store", action = "Products", id = item.ProductId, info1 = item.Category.CategoryName, info2 = item.ProductName }, Request.Url.Scheme);
        %>
        <item>
                 <title><%=item.ProductName %></title>
                 <link><%=url %></link>
                 <description><% if (dicinfo.Exists){ 
                         var files = dicinfo.GetFiles();
                         if (files.Length > 0)
                         {%>
                            <![CDATA[
                    	        <img hspace="5" width="200px" src="<%= System.Web.VirtualPathUtility.ToAbsolute(pathproducts + "/" + files[rand.Next(0, files.Length)].Name) %>"/>
                                <p><%=item.ProductSecription %></p>
 						        ]]>
                         <% }else { %>
                            <%= item.ProductSecription %>
                        <%} %>

                     <% } %>
                     <% else { %>
                        <%=item.ProductSecription %>
                     <% } %>
                 </description>
                 <category>@item.Category.CategoryName</category>
         </item>
    <% } %>

</channel>
</rss>