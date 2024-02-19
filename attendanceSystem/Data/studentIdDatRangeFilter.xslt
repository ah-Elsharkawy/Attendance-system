<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<!-- Parameters -->
	<xsl:param name="startDate" select="'2024-02-02'" />
	<xsl:param name="endDate" select="'2024-02-03'" />
	<xsl:param name="userId" select="12" />

	<!-- Template to match the users -->
	<xsl:template match="/users">
		<h2 style="text-align:center; font-weight:600; color:blue;">Student Report by Date range</h2>

		<table border="1" align="center">
			<xsl:apply-templates select="user[Id=$userId]" />
		</table>
	</xsl:template>

	<!-- Template to match the user with attendance record for the specified date -->
	<xsl:template match="user">
		<tr>
			<th colspan="2">
				Attendance records for <xsl:value-of select="name" />
			</th>
		</tr>
		<xsl:apply-templates select="attendance/record[Date=$startDate]" />
		<xsl:apply-templates select="attendance/record[Date=$endDate]" />
	</xsl:template>

	<!-- Template to match attendance record for the specified date -->
	<xsl:template match="Record">
		<tr>
			<td>
				<xsl:value-of select="Date" />
			</td>
			<td>
				<xsl:value-of select="Status" />
			</td>
		</tr>
	</xsl:template>

</xsl:stylesheet>





