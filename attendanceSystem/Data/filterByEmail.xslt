<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>
	<xsl:param name="FilterByEmail" select="'a@gmail.com'"/>
	<xsl:template match="/users">
		<!-- Start output -->
		<xsl:copy>
			<!-- Apply templates to user nodes passing the FilterByEmail parameter -->
			<xsl:apply-templates select="user[contains(Email, $FilterByEmail)]"/>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>
