
<template>
    <div>
      <template>
        <div>
          <a-table bordered :data-source="dataSource" :columns="columns" :rowKey="record => record.id" :pagination="{ pageSize: 9 }">
            <template slot="operation" slot-scope="text, record">
              <a-button type="primary" icon="edit" @click="showModal2(record)">
                更新
              </a-button>
            </template>
          </a-table>
        </div>
      </template>
      <a-modal v-model="visible2" title="修改信息" @ok="handleOk2" 
          ok-text="确认" 
          cancel-text="取消"
          @cancel="handleCancel2"
        >
        <a-form-model
          ref="ruleForm2"
          :model="form2"
          :rules="rules2"
          :label-col="labelCol2"
          :wrapper-col="wrapperCol2"
        >
          <a-form-model-item ref="id" label="客户编号" prop="id">
            <a-input
              v-model="form2.id"
              @blur="
                () => {
                  $refs.id.onFieldBlur();
                }
              "
              :readOnly="true"
            />
          </a-form-model-item>
          <a-form-model-item ref="name" label="客户姓名" prop="name">
            <a-input
              v-model="form2.name"
              @blur="
                () => {
                  $refs.name.onFieldBlur();
                }
              "
            />
          </a-form-model-item>
          <a-form-model-item ref="phone" label="客户电话" prop="phone">
            <a-input
              v-model="form2.phone"
              @blur="
                () => {
                  $refs.phone.onFieldBlur();
                }
              "
            />
          </a-form-model-item>
          <a-form-model-item ref="houseArea" label="房屋面积" prop="houseArea">
            <a-input
              v-model="form2.houseArea"
              @blur="
                () => {
                  $refs.houseArea.onFieldBlur();
                }
              "
            />
          </a-form-model-item>
           <a-form-model-item ref="monthMoney" label="房屋月租" prop="monthMoney">
            <a-input
              v-model="form2.monthMoney"
              @blur="
                () => {
                  $refs.monthMoney.onFieldBlur();
                }
              "
            />
          </a-form-model-item>
          <a-form-model-item label="房屋种类" prop="houseType">
            <a-select v-model="form2.houseType"
            >
              <a-select-option value="平房">
                平房
              </a-select-option>
              <a-select-option value="楼房">
                楼房
              </a-select-option>
              <a-select-option value="其他">
                其他
              </a-select-option>
            </a-select>
          </a-form-model-item>
          <a-form-model-item label="房屋户型" prop="houseStyle">
            <a-select v-model="form2.houseStyle"
            >
              <a-select-option value="单间">
                单间
              </a-select-option>
              <a-select-option value="一室一厅">
                一室一厅
              </a-select-option>
              <a-select-option value="三室一厅">
                三室一厅
              </a-select-option>
              <a-select-option value="独门独院">
                独门独院
              </a-select-option>
            </a-select>
          </a-form-model-item>
          <a-form-model-item label="装修情况" prop="finishCase">
            <a-select v-model="form2.finishCase"
            >
              <a-select-option value="未装修">
                未装修
              </a-select-option>
              <a-select-option value="简单装修">
                简单装修
              </a-select-option>
              <a-select-option value="中档装修">
                中档装修
              </a-select-option>
              <a-select-option value="高档装修">
                高档装修
              </a-select-option>
            </a-select>
          </a-form-model-item>
          <a-form-model-item label="出租情况" prop="rentOut">
            <a-select v-model="form2.rentOut" 
            >
              <a-select-option value="已出租">
                已出租
              </a-select-option>
              <a-select-option value="未出租">
                未出租
              </a-select-option>
            </a-select>
          </a-form-model-item>
           <a-form-model-item ref="address" label="房屋地址" prop="address">
            <a-input
              v-model="form2.address"
              @blur="
                () => {
                 $refs.address.onFieldBlur();
                }
              "
            />
          </a-form-model-item>
        </a-form-model>
      </a-modal>
    </div>
</template>
<script>

export default {

  //页面渲染前获取data.json赋值给dataSource
  created(){
    this.$http.get("/getRentMes").then(res=>{ 
      this.dataSource = res.data;
    })
  },
  data:()=>({

    // table的数据
    dataSource: [],
    count: 2,

    // 列名
    columns: [
        {
        title: '客户编号',
        dataIndex: 'id',
        width: 70,
        scopedSlots: { customRender: 'id' },
      },
      {
        title: '客户姓名',
        dataIndex: 'name',
        width: 70,
        scopedSlots: { customRender: 'name' },
      },
      {
        title: '联系电话',
        dataIndex: 'phone',
        width: 90,
        scopedSlots: { customRender: 'phone' },
      }, 
      {
        title: '房屋种类',
        dataIndex: 'houseType',
        width: 70,
        scopedSlots: { customRender: 'houseType' },
      }, 
      {
        title: '月租(￥)',
        dataIndex: 'monthMoney',
        width: 70,
        scopedSlots: { customRender: 'monthMoney' },
      }, 
      {
        title: '户型',
        dataIndex: 'houseStyle',
        width: 70,
        scopedSlots: { customRender: 'houseStyle' },
      }, 
      {
        title: '面积(㎡)',
        dataIndex: 'houseArea',
        width: 70,
        scopedSlots: { customRender: 'houseArea' },
      }, 
      {
        title: '装修情况',
        dataIndex: 'finishCase',
        width: 70,
        scopedSlots: { customRender: 'finishCase' },
      }, 
      {
        title: '房屋地址',
        dataIndex: 'address',
        width: 100,
        scopedSlots: { customRender: 'address' },
      }, 
      {
        title: '房屋情况',
        dataIndex: 'rentOut',
        width: 70,
        scopedSlots: { customRender: 'rentOut' },
      },
      {
        title: '操作',
        width: 100,
        dataIndex: 'operation',
        scopedSlots: { customRender: 'operation' },
      }
    ],

    visible2: false,  //更新弹出层
    labelCol2: { span: 4 },
    wrapperCol2: { span: 14 },
    other2: '',

    // 添加弹出层的表单数据
    form2: {
      id: '',
      name: '',
      phone:'',
      rentOut:'',
      address:'',
      finishCase: '',
      houseArea: '',
      houseType: '',
      houseStyle: '',
      monthMoney:'',
    },

    //用户需要修改的数据的编号
    updateId:"",

    // 验证表单规则用户是否输入,或输入是否合法
    rules2: {
      name:[ { required: true, message: '请正确修改房客姓名!', trigger: 'onsubmit' },],
      phone: [{ required: true, message: '请正确修改手机号码!', trigger: 'onsubmit',pattern: /^1[3|4|5|7|8][0-9]\d{8}$/,},],
      id: [ { required: true, message: '请正确修改客户编号!', trigger: 'onsubmit' },],
      rentOut: [{ required: true, message: '请正确修改出租情况!', trigger: 'onsubmit',},],
      address: [{ required: true, message: '请正确修改地址信息!', trigger: 'onsubmit' }],
      monthMoney: [{ required: true, message: '请正确修改月租金额!', trigger: 'onsubmit',pattern: new RegExp(/^[1-9]\d*$/, "g") }],
      houseStyle: [{ required: true, message: '请正确修改房间户型!', trigger: 'onsubmit' }],
      houseType: [{ required: true, message: '请正确修改房间种类!', trigger: 'onsubmit' }],
      finishCase: [{ required: true, message: '请正确修改装修信息!', trigger: 'onsubmit' }],
      houseArea: [{ required: true, message: '请正确修改装修房屋面积!', trigger: 'onsubmit',pattern: new RegExp(/^[1-9]\d*$/, "g"), }],
    }
  }),
  methods:{

    // 显示弹出层
    showModal() {

      // 赋值为true
      this.visible = true;
    },

    // showModal2(record)
    //更新的弹出层
    showModal2(rowMes) { 

      console.log(rowMes)
      //将rowMes.id赋值给this.updateId,保存用户需要修改的数据中时间
      this.updateId = rowMes.id;

      // 给form2表单绑定数据
      this.form2.id = rowMes.id;
      this.form2.name = rowMes.name;
      this.form2.phone = rowMes.phone;
      this.form2.rentOut = rowMes.rentOut;
      this.form2.finishCase = rowMes.finishCase;
      this.form2.houseArea = rowMes.houseArea;
      this.form2.houseType = rowMes.houseType;
      this.form2.houseStyle = rowMes.houseStyle;
      this.form2.address = rowMes.address;
      this.form2.monthMoney = rowMes.monthMoney;

      // 赋值为true
      this.visible2 = true;
    },

    //更新
    handleOk2(e) {

      // 回调函数参数为bool类型的valid
      this.$refs.ruleForm2.validate(valid => {

        // valid为true
        if (valid) {

            alert('修改成功!');

            // 讲表单内容赋值给对象obj
            let obj = this.form2;

            this.$http.post('/upDataMes',obj).then(res =>{
              console.log(res);
            })

            //循环找出用户要改的那条数据
            for (let i = 0; i < this.dataSource.length; i++) {
              if (this.dataSource[i].id == this.updateId) {

                // 把form2表单中数据赋值给用户要修改的数据
                this.dataSource[i].id = obj.id;
                this.dataSource[i].name = obj.name;
                this.dataSource[i].phone = obj.phone;
                this.dataSource[i].rentOut = obj.rentOut;
                this.dataSource[i].finishCase = obj.finishCase;
                this.dataSource[i].houseArea = obj.houseArea;
                this.dataSource[i].houseType = obj.houseType;
                this.dataSource[i].houseStyle = obj.houseStyle;
                this.dataSource[i].address = obj.address;
                this.dataSource[i].monthMoney = obj.monthMoney;
              }
            }

            //隐藏弹出层
            this.visible2 = false;
        } else {

          //valid为false编号重复或用户未输入
          alert('请正确修改信息!');
          return false;
        }
      });
    },

    // 更新弹出层的取消时间
    handleCancel2(){

      // 重置表单的数据
      this.$refs.ruleForm2.resetFields();
    },
  },
  components: {

  },
};
</script>
<style scoped>
.ant-table-wrapper{
  background: white;
}
.ant-form-item{
  margin-bottom: 10px;
}
.ant-modal-body {
  padding: 24px;
  padding-bottom: 10px;
} 
</style>