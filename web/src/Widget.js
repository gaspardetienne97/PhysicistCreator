import React from 'react';
import PropTypes from 'prop-types';
import {withStyles} from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import {Link} from "react-router-dom";
import Grid from "@material-ui/core/Grid";

const styles = theme => ({
    card: {
        margin: '5% auto',
        display: 'flex',
        justifyContent: 'flex-start'
    },
    cover:{
        flex: '1 1 0',
    },
    details: {
        display: 'flex',
        flexDirection: 'column',
    },
    content: {
        flex: '0 1 auto',
    },
    img: {
       width: '100%',
        height: '100%'
    },
    button: {
        display: 'flex',
        alignItems: 'center',
        paddingLeft: theme.spacing.unit,
        paddingBottom: theme.spacing.unit,
    }
});

class MediaControlCard extends React.Component{
    constructor(props){
        super(props);
    }

    render() {
    const {classes, theme} = this.props;

    return (
        <Card className={classes.card}>
            <Grid container>
                <Grid item xs={12} md={6} lg={4} className={classes.cover}>
            <CardMedia
                className={classes.img}
                image={this.props.img}
                title={this.props.name + ' Module'}
            />
                </Grid>
                <Grid item xs={12} md={6} lg={8}>
            <div className={classes.details}>
                <CardContent className={classes.content}>
                    <Typography component="h5" variant="h5">
                        {this.props.name} Module
                    </Typography>
                    <Typography variant="subtitle1" color="textSecondary">
                        {this.props.message}
                    </Typography>
                </CardContent>
                <div className={classes.button}>
                    <Link to={this.props.name}>
                        <Button  color="secondary">
                            Get Started!
                        </Button>
                    </Link>
                </div>
            </div>
                </Grid>
            </Grid>
        </Card>
    );
}
    }

MediaControlCard.propTypes = {
    classes: PropTypes.object.isRequired,
    theme: PropTypes.object.isRequired,
};

export default withStyles(styles, {withTheme: true})(MediaControlCard);