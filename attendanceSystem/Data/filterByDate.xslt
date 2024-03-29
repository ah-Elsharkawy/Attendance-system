<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>
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
                        <xsl:for-each select="//user[sClass = 'PD' and role='student']">
                            <xsl:variable name="recordDate" select="/attendance/record/date"/>
                            <xsl:if test="substring($recordDate, 1, 10) &gt;= '2024-02-01' and substring($recordDate, 1, 10) &lt;= '2024-02-07'">
                                <tr>
                                    <td>
                                        <xsl:value-of select="../../id"/>
                                    </td>
                                    <td>
                                        <xsl:value-of select="../../name"/>
                                    </td>
                                    <td>
                                        <xsl:variable name="absentCount" select="count(../../attendance/record[status='absent'])"/>
                                        <xsl:value-of select="$absentCount"/>
                                    </td>
                                </tr>
                            </xsl:if>
                        </xsl:for-each>
                    </tbody>
                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
