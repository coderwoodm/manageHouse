<template>
  <a-table :columns="columns" :data-source="data" :pagination="{ pageSize: 13 }" :rowKey="record => record.id">
    <a slot="name" slot-scope="text">{{ text }}</a>
  </a-table>
</template>
<script>
const columns = [
  {
    title: '客户编号',
    dataIndex: 'id',
    width: 60,
  },
  {
    title: '客户姓名',
    dataIndex: 'name',
    width: 70,
  },
  {
    title: '联系电话',
    dataIndex: 'phone',
    width: 70,
  }, 
  {
    title: '房屋种类',
    dataIndex: 'houseType',
    width: 70,
  },  
  {
    title: '户型',
    dataIndex: 'houseStyle',
    width: 70,
  }, 
  {
    title: '面积(㎡)',
    dataIndex: 'houseArea',
    width: 70,
  }, 
  {
    title: '装修情况',
    dataIndex: 'finishCase',
    width: 70,
  }, 
];
export default {
  created(){
    this.$http.post("/getBegSellMes").then(res=>{ 
        this.data = res.data;
    });
  },
  data:()=>({
    data:[],
    columns,
  })
};
</script>
