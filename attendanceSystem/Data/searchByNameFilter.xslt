<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:param name="substring" select="'ahmed'"/>

	<xsl:template match="/">
		
		<users>
			<xsl:for-each select="//user[contains(Name, $substring)]">
				<xsl:copy-of select="."/>
			</xsl:for-each>
		</users>
		
	</xsl:template>

</xsl:stylesheet>