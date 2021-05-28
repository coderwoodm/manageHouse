<template>
    <div id="main" :style="{backgroundImage:'url(' + bgImage + ')'}">

        <!-- 个人信息展示 -->
        <canvas id="canvas" ref="canvas" style="z-index: 100;position: fixed;top: 0;left: 0;">
        </canvas>
        
    </div>
</template>

<script>
    export default {
        data() {
            return { //canvas init
                canvas: "",
                ctx: "",
                W: "",
                H: "",
                angle: 0,
                mp: 3000,
                particles: [],
                t: 0,
                bgImage: ''
            }
        },
        mounted() {
            this.mp = 250;
            this._initCavas();
        },
        methods: {
            _initCavas() {
                this.canvas = document.getElementById("canvas");
                this.ctx = this.canvas.getContext("2d");

                //canvas dimensions
                this.W = window.innerWidth - 20;
                this.H = window.innerHeight - 10;
                this.canvas.width = this.W;
                this.canvas.height = this.H;

                //snowflake particles落的速度
                // this.mp = drop;
                this.particles = [];
                for (var i = 0; i < this.mp; i++) {
                    this.particles.push({
                        x: Math.random() * this.W, //x-coordinate
                        y: Math.random() * this.H, //y-coordinate
                        r: Math.random() * 3 + 1, //radius
                        d: Math.random() * this.mp //density
                    })
                }
                clearInterval(localStorage.getItem('interval'));
                localStorage.setItem('interval', setInterval(this.draw, 15));//下降速度
            },
            draw() {
                this.ctx.clearRect(0, 0, this.W, this.H);

                this.ctx.fillStyle = "rgba(255, 255, 255, 0.8)";//雪花背景颜色
                this.ctx.beginPath();
                for (var i = 0; i < this.mp; i++) {
                    var p = this.particles[i];
                    this.ctx.moveTo(p.x, p.y);
                    this.ctx.arc(p.x, p.y, p.r, 0, Math.PI * 2, true);//雪花圆角
                }
                this.ctx.fill();
                this.update();
            },
            update() {
                this.angle += 0.01;
                for (var i = 0; i < this.mp; i++) {
                    var p = this.particles[i];
                    p.y += Math.cos(this.angle + p.d) + 1 + p.r / 2;
                    p.x += Math.sin(this.angle) * 0.7;//飘动的距离

                    if (p.x > this.W || p.x < 0 || p.y > this.H) {
                        if (i % 3 > 0) {
                            this.particles[i] = {
                                x: Math.random() * this.W,
                                y: -10,//距离顶端的距离
                                r: p.r,
                                d: p.d
                            };
                        } else {
                            if (Math.sin(this.angle) > 0) {
                                //Enter fromth
                                this.particles[i] = {
                                    x: -5,
                                    y: Math.random() * this.H,
                                    r: p.r,
                                    d: p.d
                                };
                            } else {
                                this.particles[i] = {
                                    x: this.W + 5,
                                    y: Math.random() * this.H,
                                    r: p.r,
                                    d: p.d
                                };
                            }
                        }
                    }
                }
            }
        }
    }
</script>

<style>
#canvas{
  width: 100%;
  height: 100%;
}
    #my-info {
        width: 700px;
        height: 500px;
        border: 1px solid white;
        position: absolute;
        top: 40px;
        right: 60px;
        z-index: 101;
        border-radius: 10px;
        background-color: white;
        padding: 20px;
    }
    #main {
        margin: 0;
        padding: 0;
        width: 100%;
        height: 100%;
        background-repeat: no-repeat;
        position: absolute;
        background-size: 100% 100%;
    }
</style>