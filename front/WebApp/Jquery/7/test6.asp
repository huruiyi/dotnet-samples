<%@LANGUAGE="JAVASCRIPT" CODEPAGE="65001"%>
<%
var name = Request.Form("name");
if(name){
	Response.Write("接受到请求信息：" + name);
}
else{
	Response.Write("没有接受到请求信息！");	
}
%>