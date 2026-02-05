import { defineConfig } from 'vitepress'

export default defineConfig({
  title: "MiSAT",
  description: "Documentación para el uso de la libreria MiSAT",
  head: [['link', { rel: 'icon', href: '' }]],
  themeConfig: {
    nav: [
      { text: 'Home', link: '/' },
      { text: 'Documentacion', link: '/api/' },
      { text: 'v1.6.2' , link: ''},
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
              { text: 'Obtener', link: '/api/obtener' },
              { text: 'Generar Solicitud Consulta', link: '/api/generar-solicitud-consulta' },
              { text: 'Deserializar Consulta', link: '/api/deserializar-consulta' }
            ]
          },
          { 
            text: 'Descarga Masiva', 
            items: [
              { text: 'Generar Solicitud Autenticacion', link: '/api/generar-solicitud-autenticacion' },
              { text: 'Deserializar Autenticacion', link: '/api/deserializar-autenticacion' },
              { text: 'Generar Solicitud Descarga', link: '/api/generar-solicitud-descarga' },
              { text: 'Deserializar Descarga', link: '/api/deserializar-descarga' },
              { text: 'Generar Solicitud Verificacion', link: '/api/generar-solicitud-verificacion' },
              { text: 'Deserializar Verificacion', link: '/api/deserializar-verificacion'},
              { text: 'Generar Solicitud Descarga Paquete', link: '/api/generar-solicitud-descarga-paquete' },
              { text: 'Obtener Paquete', link: '/api/obtener-paquete' }
            ]
          }
        ]
      },
      {
        text: 'Modelos',
        link: '/models/',
        items: [
          { text: 'Comprobante', link: '/models/comprobante' },
          { text: 'Envelope', link: '/models/envelope' },
          { text: 'Autenticacion', link: '/models/autenticacion' },
          { text: 'Consulta CFDI', link: '/models/consulta-cfdi',
            items: [
              { text: 'Solicitud Consulta CFDI', link: '/models/solicitud-consulta-cfdi' },
              { text: 'Consulta Result', link: '/models/consulta-result' }
            ]
          },
          { text: 'Solicitud Descarga', link: '/models/solicitud-descarga', 
            items: [
              { text: 'Solicitud Descarga Emitidos', link: '/models/solicitud-descarga-emitidos' },
              { text: 'Solicitud Descarga Recibidos', link: '/models/solicitud-descarga-recibidos' },
              { text: 'Solicitud Descarga Folio', link: '/models/solicitud-descarga-folio' },
              { text: 'Solicitud Descarga Result', link: '/models/solicita-descarga-result' }
          ]},
          { text: 'Verificacion', link: '/models/verificacion' ,
            items: [
              { text: 'Solicitud Verificacion', link: '/models/solicitud-verificacion' },
              { text: 'Solicitud Verificacion Result', link: '/models/verifica-descarga-result' }
          ]},
          { text: 'Descarga Paquete', link: '/models/descarga-paquete',
            items: [
              { text: 'Solicitud Descarga Paquetes', link: '/models/solicitud-descarga-paquetes' },
              { text: 'Paquete Response', link: '/models/paquete-response' }
            ]
          }
        ]
      }
    ],

    socialLinks: [
      { icon: 'github', link: 'https://github.com/ricardomiss/MISAT' },
      { icon: 'nuget', link: 'https://www.nuget.org/packages/MiSAT' }
    ],
    footer: {
      message: 'Released under the <a href="https://github.com/ricardomiss/MISAT/blob/master/LICENSE.txt">MIT</a> License.<br/>Made with ❤️ by <a href="https://github.com/ricardomiss">Ricardo Miss</a> and Powered by <a href="https://vitepress.vuejs.org/">VitePress</a>',
      copyright: 'Copyright © 2025-present <a href="https://github.com/ricardomiss">Ricardo Miss</a>',
    }
  },
  base: '/MISAT/'
})
