/**
 * @license Copyright (c) 2003-2014, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.extraPlugins = 'lineheight';
    config.line_height = "20pt;21pt;22pt;23pt;24pt;25pt;26pt;27pt;28pt;29pt;30pt";
    //    config.enterMode = CKEDITOR.ENTER_P;
    config.enterMode = CKEDITOR.ENTER_BR;
    config.fontSize_sizes = '8/8pt;9/9pt;10/10pt;11/11pt;12/12pt;13/13pt;14/14pt;15/15pt;16/16pt;17/17pt;18/18pt;19/19pt;20/20pt;21/21pt;22/22pt;23/23pt;24/24pt;25/25pt;';
    config.font_names = 'Helvetica, Arial, sans-serif;Times New Roman/Times New Roman,Times,serif;Verdana;Calibri';
};
