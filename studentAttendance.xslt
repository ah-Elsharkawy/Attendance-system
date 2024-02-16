<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>
	<xsl:param name= "studentID"/>
	<xsl:variable name="users" select="document('user.xml')"/>
    <xsl:template match="/">
    <html>
        <h2>Attendance for student <xsl:value-of select ="$studentID"/></h2>
        <table>
        <tr>
        <th>date</th>
        <th>status</th>
        <th>student Name</th>
        </tr>
        
        <xsl:for-each select= "attendance/record">
            <xsl:if test="std_id = 17">
                <tr>
                    <td><xsl:value-of select="date"/></td>
                    <td><xsl:value-of select="attendance_status"/></td>
                    <td>
                    <xsl:variable name="studentName" select="$users/Users/User[ID = current()/std_id]/Name"/>
                    <xsl:value-of select="$studentName"/>
                    </td>
                    
                </tr>
            </xsl:if>
        </xsl:for-each>
        </table>
    </html>

    </xsl:template>
	
</xsl:stylesheet>
