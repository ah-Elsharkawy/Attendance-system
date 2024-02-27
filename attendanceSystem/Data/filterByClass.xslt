<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>

	<!-- Define a parameter to filter students by class -->
	<xsl:param name="classFilter" select="'PD'"/>

	<xsl:template match="/">
		<html>
			<head>
				<title>Class Report</title>
			</head>
			<body>
				<h2 style="text-align:center; font-weight:600; color:blue;">Class Report</h2>
				<table width="400" cellpadding="10" cellspacing="10" align="center" border="1">
					<thead>
						<tr>
							<th>Student ID</th>
							<th>Name</th>
							<!-- <th>Absent Days</th> -->
							<th>Class</th>
							<th>Date</th>
							<th>Status</th>
						</tr>
					</thead>
					<tbody style="text-align:center">
						<!-- Filter students by the specified class using the param -->
						<xsl:for-each select="//user[SClass = $classFilter and Role = 'Student']">
							<xsl:variable name="studentId" select="Id"/>
							<xsl:variable name="studentName" select="Name"/>
							<!--  <xsl:variable name="absentCount" select="count(Attendance/Record[Status='absent'])"/> -->
							<xsl:for-each select="Attendance/Record">
								<tr>
									<td>
										<xsl:value-of select="$studentId"/>
									</td>
									<td>
										<xsl:value-of select="$studentName"/>
									</td>
									<!--   <td><xsl:value-of select="$absentCount"/></td>  -->
									<td>
										<xsl:value-of select="../../SClass"/>
									</td>
									<td>
										<xsl:value-of select="Date"/>
									</td>
									<td>
										<xsl:value-of select="Status"/>
									</td>
								</tr>
							</xsl:for-each>
						</xsl:for-each>
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>