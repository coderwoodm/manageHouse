<template>
    <div id="body">
      <remote-css href="static/css/normalize.css"></remote-css>
      <remote-css href="static/css/htmleaf-demo.css"></remote-css>
      <remote-js src="static/js/undersore.js"></remote-js>
      <!-- <remote-js src="static/js/script.js"></remote-js> -->
	  </div>
</template>
<script>

export default {
  destroyed(){
  },
  created(){
    
  },
  data:()=>({
    welcome:"欢迎进入房屋中介管理系统!",
  }),
  methods:{

  },
  components:{
    'remote-css': {
      render(createElement) {            
        return createElement('link', { attrs: { rel: 'stylesheet', href: this.href }});
      },
      props: {
        href: { type: String, required: true },
      },
    },
    'remote-js': {
      render(createElement) {
        return createElement('script', { attrs: { type: 'text/javascript', src: this.src }});            
      },
      props: {
        src: { type: String, required: true },
      },
    },
  }
}
</script>
<style scoped>
#body{
  position: relative;
  height: 100%;
}
</style>
