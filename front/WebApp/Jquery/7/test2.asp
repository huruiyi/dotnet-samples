<%@LANGUAGE="JAVASCRIPT" CODEPAGE="65001"%>
<%
var name = Request.Form("name");
if(name && name == "css8"){
	Response.Write(name + "是合法的用户名。");
}
else{
	Response.Write(name + "非法的用户名");	
}

%>

