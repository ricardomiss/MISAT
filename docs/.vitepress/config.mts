import { defineConfig } from 'vitepress'

// https://vitepress.dev/reference/site-config
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
              { text: 'Generar Solicitud Autenticacion', link: '/api/generarsolicitudautenticacion' },
              { text: 'Generar Solicitud Descarga', link: '/api/generarsolicituddescarga' },
              { text: 'Deserializar Autenticacion', link: '/api/deserializarautenticacion' }
            ]
          }
        ]
      }
    ],

    socialLinks: [
      { icon: 'github', link: 'https://github.com/ricardomiss/MISAT' }
    ],
    footer: {
      message: 'Released under the MIT License.',
      copyright: 'Copyright © 2025-present Ricardo Miss'
    }
  },
  base: '/MISAT/'
})
