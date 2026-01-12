import { defineConfig } from 'vitepress'

export default defineConfig({
  title: "MiSAT",
  description: "Documentación para el uso de la libreria MiSAT",
  head: [['link', { rel: 'icon', href: '' }]],
  themeConfig: {
    nav: [
      { text: 'Home', link: '/' },
      { text: 'Documentacion', link: '/api/' }
    ],

    sidebar: [
      {
        text: 'Inicio Rápido',
        link: '/quickstart'
      },
      {
        text: 'API',
        link: '/api/',
        items: [
          { 
            text: 'CFDI', 
            items: [
              { text: 'Obtener', link: '/api/obtener' }
            ]
          },
          { 
            text: 'Descarga Masiva', 
            items: [
              { text: 'Generar Solicitud Autenticacion', link: '/api/generar-solicitud-autenticacion' },
              { text: 'Generar Solicitud Descarga', link: '/api/generar-solicitud-descarga' },
              { text: 'Deserializar Autenticacion', link: '/api/deserializar-autenticacion' }
            ]
          }
        ]
      },
      {
        text: 'Modelos',
        link: '/models/',
        items: [
          { text: 'Comprobante', link: '/models/cfdi' },
        ]
      }
    ],

    socialLinks: [
      { icon: 'github', link: 'https://github.com/ricardomiss/MISAT' }
    ],
    footer: {
      message: 'Released under the <a href="https://github.com/ricardomiss/MISAT/blob/master/LICENSE.txt">MIT</a> License.<br/>Made with ❤️ by <a href="https://github.com/ricardomiss">Ricardo Miss</a> and Powered by <a href="https://vitepress.vuejs.org/">VitePress</a>',
      copyright: 'Copyright © 2025-present <a href="https://github.com/ricardomiss">Ricardo Miss</a>',
    }
  },
  base: '/MISAT/'
})
