<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>
	<xsl:param name="classFilter" select= " 'OS' " />
	<xsl:template match="/">
		<html>
			<head>
				<title>Class Report</title>
			</head>
			<body>
				<h2 style="text-align:center; font-weight:600; color:blue;">Class Report</h2>
				<table width="200" cellpadding="10" cellspacing="10" align="center" border="1">
					<thead>
						<tr>
							<th>Student ID</th>
							<th>Name</th>
							<th>Absent Days</th>
						</tr>
					</thead>
					<tbody style="text-align:center">
						<xsl:for-each select="//user[SClass = $classFilter and Role='Student']">
							<tr>
								<td>
									<xsl:value-of select="Id"/>
								</td>
								<td>
									<xsl:value-of select="Name"/>
								</td>
								<td>
									<xsl:variable name="absentCount" select="count(Attendance/Record[Status='absent'])"/>
									<xsl:value-of select="$absentCount"/>
								</td>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
