<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  
  <!-- Parameter to specify the user ID -->
  <xsl:param name="userId" select="12" />
  
  <!-- Template to match the users -->
  <xsl:template match="/users">
    <h2 style="text-align:center; font-weight:600; color:blue;">Student Report by ID</h2>
    <table border="1" align="center">
      <!-- Apply templates only to the user with the specified ID -->
      <xsl:apply-templates select="user[id=$userId]" />
    </table>
  </xsl:template>
  
  <!-- Template to match the user with attendance record -->
  <xsl:template match="user">
    <tr>
      <th colspan="2">Attendance records for <xsl:value-of select="name" /> whose id is <xsl:value-of select="id" /></th>
    </tr>
    <!-- Apply templates to each attendance record -->
    <xsl:apply-templates select="attendance/record" />
  </xsl:template>
  
  <!-- Template to match attendance record -->
  <xsl:template match="record">
    <!-- Display only the status for each record -->
    <tr>
      <td><xsl:value-of select="status" /></td>
            <td><xsl:value-of select="date" /></td>
    </tr>
  </xsl:template>
  
</xsl:stylesheet>
