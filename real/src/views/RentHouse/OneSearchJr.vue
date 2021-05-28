<template>
  <a-form-model
    ref="ruleForm"
    :model="form"
    :rules="rules"
    :label-col="labelCol"
    :wrapper-col="wrapperCol"
  >
    <a-form-model-item ref="area" label="建筑面积" prop="area">
      <a-input
        v-model="form.area"
        @blur="
          () => {
            $refs.area.onFieldBlur();
          }
        "
      />
    </a-form-model-item>
    <a-form-model-item ref="money" label="每月价格" prop="money">
      <a-input
        v-model="form.money"
        @blur="
          () => {
            $refs.money.onFieldBlur();
          }
        "
      />
    </a-form-model-item>
    <a-form-model-item label="房屋种类" prop="houseType">
      <a-select v-model="form.houseType">
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
    <a-form-model-item label="户型" prop="houseStyle">
      <a-select v-model="form.houseStyle">
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
      <a-select v-model="form.finishCase">
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
    <a-form-model-item label="性别" prop="sex">
      <a-select v-model="form.sex">
        <a-select-option value="男">
          男
        </a-select-option>
        <a-select-option value="女">
          女
        </a-select-option>
        <a-select-option value="男女不限">
          男女不限
        </a-select-option>
      </a-select>
    </a-form-model-item>
    <a-form-model-item :wrapper-col="{ span: 14, offset: 4 }">
      <a-button type="primary" @click="onSubmit">
        查询
      </a-button>
      <a-button style="margin-left: 10px;" @click="resetForm">
        重置
      </a-button>
    </a-form-model-item>
    <template>
      <a-table
        :columns="columns"
        :data-source="searchList"
        :pagination="false"
        :scroll="{ y: 240 }"
        :rowKey="record => record.id"
      />
    </template>
  </a-form-model>
</template>
<script>
export default {
  created(){
      this.$http.get("/getRentMesTwo").then(res=>{ 
         this.searchList = res.data;
      });
  },
  data:()=>(
    {
      labelCol: { span: 4 },
      wrapperCol: { span: 14 },
      // other: '',
      form: {
        area: '',
        money: "",
        houseType: "",
        houseStyle: "",
        finishCase: "",
        sex:""
      },
      searchList :[],
      rules: {
        
      },
      columns,
  }),
  methods: {
    onSubmit() {
        let obj = this.form;
        if (obj.sex == "" && obj.houseArea == "" && obj.monthMoney == "" && obj.houseType == "" && obj.houseStyle == "" && obj.finishCase == "") {
          this.resetForm();
        }else{
          this.$http.post("/getScreenMesTwo",obj).then(res=>{ 
            this.searchList = res.data;
          });
        }
    },
    resetForm() {
      this.$refs.ruleForm.resetFields();
      this.$http.get("/getRentMesTwo").then(res=>{ 
         this.searchList = res.data;
      });
    }
  },
  components:{
  }
};
const columns = [
  {
    title: '编号',
    dataIndex: 'id',
    width: 70,
  },
  {
    title: '客户姓名',
    dataIndex: 'name',
    width: 60,
  },
  {
    title: '联系电话',
    dataIndex: 'phone',
    width: 100,
  }, 
  {
    title: '房屋种类',
    dataIndex: 'houseType',
    width: 60,
  }, 
  {
    title: '月租(￥)',
    dataIndex: 'monthMoney',
    width: 60,
  }, 
  {
    title: '户型',
    dataIndex: 'houseStyle',
    width: 60,
  }, 
  {
    title: '面积(㎡)',
    dataIndex: 'houseArea',
    width: 60,
  }, 
  {
    title: '装修情况',
    dataIndex: 'finishCase',
    width: 70,
  }, 
  {
    title: '房屋地址',
    dataIndex: 'address',
    width: 100,
  }, 
  {
    title: '房屋情况',
    dataIndex: 'rentOut',
    width: 60,
  }, 
  {
    title: '性别',
    dataIndex: 'sex',
    width: 70,
  }
];
</script>
<style scoped>
.ant-input,form .ant-select{
  width: 35% !important;
}
.ant-btn{
  margin-left: 38px !important;
}
.ant-table-tbody > tr > td{
  text-align: center !important;
}
.ant-form-item{
  margin-bottom: 15px !important;
}
a-table ul{
  display: none !important;
}
</style>