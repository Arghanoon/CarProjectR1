<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" ContentType="application/xml" %><%@ Import Namespace="System.IO" %><?xml version="1.0" encoding="UTF-8"?>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9" xmlns:image="http://www.google.com/schemas/sitemap-image/1.1" > 

    <% 
        var dbs = new CarProject.DBSEF.CarAutomationEntities();
        var products = dbs.Products.OrderByDescending(p => p.ProductId).Take(50);
        var rand = new Random();
    %>

    <% foreach (var item in products)
       {
           var pathproducts = "~/Publics/Gallery/ProductImages/" + item.ProductId;
           var dicinfo = new DirectoryInfo(Server.MapPath(pathproducts));
           %>
        <url>
            <loc><%=Url.RouteUrl("infoRoute", new { controller = "Store", action = "Products", id = item.ProductId, info1 = item.Category.CategoryName, info2 = item.ProductName }, Request.Url.Scheme) %></loc>
            
            <% if (dicinfo.Exists)
               {
                   var files = dicinfo.GetFiles();
                   if(files.Length > 0) {%>
                        <image:image>
                            <image:loc><%=new Uri(Request.Url,Url.Content(pathproducts + "/" + files[rand.Next(0, files.Length)].Name)) %></image:loc>
                            <image:caption><%=item.ProductName %></image:caption>
                        </image:image>
                <% } %>
            <% } %>
        </url>           
     <%  } %>
        	
	
</urlset>