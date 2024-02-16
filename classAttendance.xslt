<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>
    
    <!-- Define parameter for class name -->
    <xsl:param name="class"/>

    <!-- Load user XML file -->
    <xsl:variable name="users" select="document('user.xml')"/>

    <!-- Template to match the root node -->
    <xsl:template match="/">
        <html>
           
            <body>
                <h1>Class Attendance for Class: <xsl:value-of select="$class"/></h1>
                <table border="1">
                    <tr>
                        <th>Date</th>
                        <th>Student Name</th>
                        <th>Attendance Status</th>
                    </tr>
                    <!-- Apply template for each attendance record -->
                    <xsl:apply-templates select="//record[std_id=$users/Users/User[Class='Lab2']/ID]"/>
                </table>
            </body>
        </html>
    </xsl:template>

    <!-- Template to match each attendance record -->
    <xsl:template match="record">
        <tr>
            <!-- Extract date -->
            <td><xsl:value-of select="date"/></td>
            <!-- Use user ID to find corresponding user's name -->
            <td>
                <xsl:value-of select="$users/Users/User[ID=current()/std_id]/Name"/>
            </td>
            <!-- Extract attendance status -->
            <td><xsl:value-of select="attendance_status"/></td>
        </tr>
    </xsl:template>
</xsl:stylesheet>
